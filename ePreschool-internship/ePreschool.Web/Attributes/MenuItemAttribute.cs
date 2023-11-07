namespace ePreschool.Web.Attributes
{
    public class MenuItemAttribute : Attribute
    {
        public MenuItem MenuItem { get; set; }

        public MenuItemAttribute(MenuItem menuItem)
        {
            MenuItem = menuItem;
        }
    }

    public enum MenuItem
    {
        Home,
        Settings,      
        Cities,
        Countries,
        Users,
        BusinessUnits,
        Preschools,
        WorkingPrograms,
        Children
    }
}
