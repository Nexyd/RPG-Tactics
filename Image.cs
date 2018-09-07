// Daniel Morato Baudi.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG_Tactics
{
    /// <summary>
    /// Sets and provides all the necessary methods and attributes for the game images.
    /// </summary>
    class Image : Microsoft.Xna.Framework.Game
    {
        #region Attributes
        private Texture2D texture;
        private Vector2 position;
        private Vector2 speed;
        private int rowFrames;
        private int columnFrames;
        private int actualFrameRow;
        private int actualFrameColumn;
        private int actualImage;
        private bool highlighted;
        private bool visible;
        private BoundingBox box;
        #endregion

        #region Constructors
        /// <summary>
        /// Initiallizes a new empty Image.
        /// </summary>
        public Image()
        {
            position = Vector2.Zero;
            speed = Vector2.Zero;
            rowFrames = 1;
            columnFrames = 1;
            actualFrameRow = 0;
            actualFrameColumn = 0;
            actualImage = 0;
            highlighted = false;
            visible = true;
            box = new BoundingBox();
        }

        /// <summary>
        /// Initiallizes a new Image with the number of rows and columns of frames.
        /// </summary>
        /// <param name="rowFrames">Number of rows of frames the image is going to be split in.</param>
        /// <param name="columnFrames">Number of columns of frames the image is going to be split in.</param>
        public Image(int rowFrames, int columnFrames) : this()
        {
            this.rowFrames = rowFrames;
            this.columnFrames = columnFrames;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public Texture2D Texture
        {
            get { return texture;  }
            set { texture = value; }
        }

        /// <summary>
        /// Gets or sets the position in pixels.
        /// </summary>
        public Vector2 Position
        {
            get { return position;  }
            set { 
                position = value;
                box = new BoundingBox(
                    new Vector3(value, 0),
                    new Vector3(value.X + 
                        Texture.Width, value.Y +
                        Texture.Height, 0));
            }
        }

        /// <summary>
        /// Gets or sets the position in tiles (32x32).
        /// </summary>
        public Vector2 GamePosition
        {
            get { return position / 32;  }
            set { 
                position = value * 32; 
                box = new BoundingBox(
                    new Vector3(value * 32, 0),
                    new Vector3(value.X * 32 + 
                        Texture.Width, value.Y * 32
                        + Texture.Height, 0));
            }
        }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        public Vector2 Speed
        {
            get { return speed;  }
            set { speed = value; }
        }

        /// <summary>
        /// Gets or sets the number of rows of frames the image has.
        /// </summary>
        public int RowFrames
        {
            get { return rowFrames;  }
            set { rowFrames = value; }
        }

        /// <summary>
        /// Gets or sets the number of columns of frames the image has.
        /// </summary>
        public int ColumnFrames
        {
            get { return columnFrames;  }
            set { columnFrames = value; }
        }

        /// <summary>
        /// Gets or sets the actual frame row displaying.
        /// </summary>
        public int ActualFrameRow
        {
            get { return actualFrameRow;  }
            set { actualFrameRow = value; }
        }

        /// <summary>
        /// Gets or sets the actual frame column displaying.
        /// </summary>
        public int ActualFrameColumn
        {
            get { return actualFrameColumn;  }
            set { actualFrameColumn = value; }
        }

        /// <summary>
        /// Gets or sets the actual image displaying.
        /// </summary>
        public int ActualImage
        {
            get { return actualImage;  }
            set { actualImage = value; }
        }

        /// <summary>
        /// Gets or sets the highlight image status.
        /// </summary>
        public bool Highlighted
        {
            get { return highlighted;  }
            set { highlighted = value; }
        }

        /// <summary>
        /// Gets or sets the visibility of the image.
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        /// <summary>
        /// Gets or sets the image's collision box.
        /// </summary>
        public BoundingBox Box
        {
            get { return box;  }
            set { box = value; }
        }
        #endregion
    }
}