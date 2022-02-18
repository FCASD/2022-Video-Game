using System.Collections.Generic;
using Godot;

namespace TSAVideoGame
{
    public class Player : KinematicBody2D
    {
        [Export] public int Speed;

        public Vector2 ScreenSize;

        private List<RigidBody2D> _nearbyNpcs;

        public RigidBody2D EngagedNpc
        {
            get
            {
                if (_nearbyNpcs.Count > 0)
                {
                    RigidBody2D closest = _nearbyNpcs[0];
                    foreach (RigidBody2D npc in _nearbyNpcs)
                    {
                        closest = closest.Position.DistanceSquaredTo(Position) >
                                  npc.Position.DistanceSquaredTo(Position)
                            ? npc
                            : closest;
                    }

                    return closest;
                }

                return null;
            }
        }

        public override void _Ready()
        {
            ScreenSize = GetViewportRect().Size;
            GD.Print("Player loaded");
            _nearbyNpcs = new List<RigidBody2D>();
        }

        public override void _Process(float delta)
        {
            Vector2 velocity = Vector2.Zero;

            ZIndex = (int) Position.y;

            if (Input.IsActionPressed("move_right"))
            {
                velocity.x += 1;
            }
            else if (Input.IsActionPressed("move_left"))
            {
                velocity.x -= 1;
            }

            if (Input.IsActionPressed("move_down"))
            {
                velocity.y += 1;
            }
            else if (Input.IsActionPressed("move_up"))
            {
                velocity.y -= 1;
            }

            AnimatedSprite animSprite = GetNode<AnimatedSprite>("AnimatedSprite");

            if (velocity.Length() > 0)
            {
                animSprite.Animation = "walk";
                velocity = velocity.Normalized() * Speed;
            }
            else
            {
                animSprite.Animation = "idle";
            }

            animSprite.Play();

            MoveAndCollide(velocity * delta);

            // Position = new Vector2(
            //     x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
            //     y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
            // );

            if (velocity.x != 0)
            {
                animSprite.FlipV = false;
                animSprite.FlipH = velocity.x < 0;
            }
            
            GD.Print(EngagedNpc?.Name);
        }

        public void OnNpcEntered(Area2D npcArea)
        {
            RigidBody2D npc = npcArea.GetParent<RigidBody2D>();
            if (_nearbyNpcs.Contains(npc)) _nearbyNpcs.Remove(npc);
            _nearbyNpcs.Add(npc);
        }

        public void OnNpcExited(Area2D npcArea)
        {
            RigidBody2D npc = npcArea.GetParent<RigidBody2D>();
            if (_nearbyNpcs.Contains(npc)) _nearbyNpcs.Remove(npc);
        }
    }
}