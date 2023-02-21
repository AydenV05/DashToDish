using UnityEngine;

public class Items
{
    public string ProductName { get; set; }
    public Texture2D Foto { get; set; }

    public bool isCheckedOff;



    public Items(string productName)
    {
        ProductName = productName;
        PickPicture(productName);
    }

    private Texture2D PickPicture(string name)
    {
        switch (name)
        {
            case "Tomato": return Resources.Load<Texture2D>("Images/Tomato");
            case "Fries": return Resources.Load<Texture2D>("Images/Fries");
            case "Milk": return Resources.Load<Texture2D>("Images/Milk");
            case "Carrot": return Resources.Load<Texture2D>("Images/Carrot");
            case "Pasta": return Resources.Load<Texture2D>("Images/Pasta");
            case "Beans": return Resources.Load<Texture2D>("Images/Beans");
            case "Cookie": return Resources.Load<Texture2D>("Images/Cookie");
            case "Candy": return Resources.Load<Texture2D>("Images/Candy");
            case "Water": return Resources.Load<Texture2D>("Images/Water");
            case "Coke": return Resources.Load<Texture2D>("Images/Coke");
            case "Fish": return Resources.Load<Texture2D>("Images/Fish");
            case "Meat": return Resources.Load<Texture2D>("Images/Meat");
            default: return Resources.Load<Texture2D>("Images/NoImage");
        }
    }

    [SerializeField] Texture2D imageTomato;
    [SerializeField] Texture2D imageFry;
    [SerializeField] Texture2D imageMilk;
    [SerializeField] Texture2D imageCarrot;
    [SerializeField] Texture2D imagePasta;
    [SerializeField] Texture2D imageBeans;
    [SerializeField] Texture2D imageCookie;
    [SerializeField] Texture2D imageSnoep;
    [SerializeField] Texture2D imageWater;
    [SerializeField] Texture2D imageCoke;
    [SerializeField] Texture2D imageFish;
    [SerializeField] Texture2D imageMeat;

    [SerializeField] Texture2D noImage;
}

