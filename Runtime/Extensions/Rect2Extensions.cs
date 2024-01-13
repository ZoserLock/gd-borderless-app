using Godot;
using System;

namespace Zen.Core
{
    public enum EPointDirection
    {
        Inside,
        Left,
        Right,
        Top,
        Bottom,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public static class RectExtensions
    {
        public static int ToWin32(this EPointDirection direction)
        {
            switch (direction)
            {
                case EPointDirection.Inside:
                    return W32Consts.HTCLIENT;
                case EPointDirection.Left:
                    return W32Consts.HTLEFT;
                case EPointDirection.Right:
                    return W32Consts.HTRIGHT;
                case EPointDirection.Top:
                    return W32Consts.HTTOP;
                case EPointDirection.Bottom:
                    return W32Consts.HTBOTTOM;
                case EPointDirection.TopLeft:
                    return W32Consts.HTTOPLEFT;
                case EPointDirection.TopRight:
                    return W32Consts.HTTOPRIGHT;
                case EPointDirection.BottomLeft:
                    return W32Consts.HTBOTTOMLEFT;
                case EPointDirection.BottomRight:
                    return W32Consts.HTBOTTOMRIGHT;
                default:
                    return 0;
            }
        }

        public static Rect2 Inset(this Rect2 rect, float inset)
        {
            return new Rect2(rect.Position.X + inset, rect.Position.Y + inset, rect.Size.X - inset * 2, rect.Size.Y - inset * 2);
        }

        public static Rect2 Inset(this Rect2 rect, float x, float y)
        {
            return new Rect2(rect.Position.X + x, rect.Position.Y + y, rect.Size.X - x * 2, rect.Size.Y - y * 2);
        }

        public static EPointDirection GetPointDirection(this Rect2 rect, Vector2 point)
        {
            if (rect.HasPoint(point))
            {
                return EPointDirection.Inside;
            }
            else if (point.X < rect.Position.X)
            {
                if (point.Y < rect.Position.Y)
                {
                    return EPointDirection.TopLeft;
                }
                else if (point.Y > rect.End.Y)
                {
                    return EPointDirection.BottomLeft;
                }
                else
                {
                    return EPointDirection.Left;
                }
            }
            else if (point.X > rect.End.X)
            {
                if (point.Y < rect.Position.Y)
                {
                    return EPointDirection.TopRight;
                }
                else if (point.Y > rect.End.Y)
                {
                    return EPointDirection.BottomRight;
                }
                else
                {
                    return EPointDirection.Right;
                }
            }
            else
            {
                if (point.Y < rect.Position.Y)
                {
                    return EPointDirection.Top;
                }
                else
                {
                    return EPointDirection.Bottom;
                }
            }
        }
    }
}