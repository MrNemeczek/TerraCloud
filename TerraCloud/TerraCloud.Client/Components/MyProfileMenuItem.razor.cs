using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Microsoft.AspNetCore.Components.Routing;

namespace TerraCloud.Client.Components
{
    public partial class MyProfileMenuItemBase : RadzenComponent
    {
        [Parameter]
        public EventCallback<MouseEventArgs> Click { get; set; }
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "rz-navigation-item";
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string ImageAlternateText { get; set; } = "image";

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        [Parameter]
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [Parameter]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the navigation link match.
        /// </summary>
        /// <value>The navigation link match.</value>
        [Parameter]
        public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the icon color.
        /// </summary>
        /// <value>The icon color.</value>
        [Parameter]
        public string IconColor { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Parameter]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Parameter]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>The menu.</value>
        [CascadingParameter]
        public RadzenProfileMenu Menu { get; set; }

        RadzenProfileMenu _parent;
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        [CascadingParameter]
        public RadzenProfileMenu Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent != value)
                {
                    _parent = value;

                    _parent.AddItem(Map(this));
                }
            }
        }

        bool clicking;
        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public virtual async Task OnClick(MouseEventArgs args)
        {
            if (clicking)
            {
                return;
            }

            try
            {
                clicking = true;

                await Click.InvokeAsync(args);
            }
            finally
            {
                clicking = false;
            }
        }

        private RadzenProfileMenuItem Map(MyProfileMenuItemBase item)
        {
            var menuItem = new RadzenProfileMenuItem
            {
                Attributes = item.Attributes,
                Culture = item.Culture,
                IconColor = item.IconColor,
                Text = item.Text,
                Icon = item.Icon,
                UniqueID = item.UniqueID,
                Path = item.Path,
                Target = item.Target,
                Image = item.Image,
                ImageAlternateText = item.ImageAlternateText,
                Value = item.Value
            };

            menuItem.ContextMenu = item.ContextMenu;
            return menuItem;

        }

    }
}
