using Domain.Entities;
using Domain.ValueObjects;

//"RU", "US", "CA", "GB", "FR", "DE", "IT", "ES", "JP", "CN"
try
{
    Country q = new Country("Russia", "AH");
    Drug b = new Drug("Paraцетомол №10 20мг", "Ruссия", "AH");
    Address a = new Address("Tiraspol", "Sverdlova", "99", "30199", "036");

    DrugNetwork dn = new DrugNetwork("E-Apteka"); 
    DrugStore v = new DrugStore(dn, 3, a);
    Console.WriteLine(v.DrugNetwork.Name);
    DrugStore g = new DrugStore(dn, 3, a);
    Console.WriteLine(dn.Stores.Count);
}catch(Exception ex){Console.WriteLine(ex.Message);}
try
{
    /*Country q = new Country("Russia", "FR");*/
//
    /*Drug b = new Drug("Paraцетомол №10 20мг", "Ruссия", "RU");*/
//
    /*Address a = new Address("Tiraspol", "Sverdlova", "99", "301", "037");*/
//
    
//
   
}catch(Exception ex){Console.WriteLine(ex);}

/*
try
{
    using (var context = new Context())
    {
        context.Countries.Add(q);
        //context.Drugs.Add(b);
        //context.DrugStores.Add(v);
        context.SaveChanges();
        Console.Read();
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

//DrugItem v = new DrugItem(Drug.Id, );

//Drug a = new Drug("Apteka", "Apteka", b);
//DrugStore g = new DrugStore("E-Apteka", 4, null);
//DrugItem c = new DrugItem(Convert.ToDecimal(10.33), 105, a, g);




