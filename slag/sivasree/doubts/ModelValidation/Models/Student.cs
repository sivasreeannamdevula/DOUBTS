using System.ComponentModel.DataAnnotations;     //to use data annotations we should import this

public class Student
{
    [Required(ErrorMessage ="GIVE APPROPRIATE VALUE")]
    public int ID{get;set;}


    [MaxLength(7),MinLength(1)]
    public string Name{get;set;}


    [StringLength(89)]
    public string FavSubject{get;set;}

    [EmailAddress(ErrorMessage ="ENTER VALID EMAIL")]
    public string Email{get;set;}


    //  [Phone]
    public long PhoneNumber{get;set;}


    // [Range(1,20)]
    // public int Age{get;set;}

    [ExternalValidation]
    public int AdmissionDate{get;set;}
}