
//create dbcontext intsance
    ShopContext shopContext=new ShopContext();
    MaxShowroom maxShowroom=new MaxShowroom();
    
    Zudio zudio1=new Zudio();
    Zudio zudio2=new Zudio();
    
            zudio1.BranchName="Vizag";
            zudio1.ItemName="white Tee";
         
            zudio2.BranchName="Hyderabad";
            zudio2.ItemName="Black Tee";
   shopContext.ZudioTable.Add(zudio1);
   shopContext.ZudioTable.Add(zudio2);
   shopContext.SaveChanges();