using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourist_Platform.Models
{
    [Table("AdminLogin")]
    public class AdminLogic
    {
        [Key]
        [Display(Name ="Admin Id")]
        public int AdminId { get; set; }
        [Display(Name = "Admin Name")]
        [Required(ErrorMessage = ("Admin Name can't be blank"))]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Admin Name must be 6 - 50 character")]
        [Column(TypeName = "nvarchar")]
        public string AdminName { get; set; }
        [Display(Name = "Admin Username")]
        [Required(ErrorMessage = ("Admin Username can't be blank"))]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Admin Username must be 6 - 20 character")]
        public string AdminUsername { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = ("Password can't be blank"))]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#&()–[{}]:;',?/*~$^+=<>]).{8,20}$",
        ErrorMessage = "Password must contains at least 1 digit[0-9]," +
            " 1 lowercase[a-z]," +
            " 1 uppercase[A-Z]," +
            "1 special character like !@#," +
            " 8 - 20 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "Confirm Password must be the same as Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

    [Table("UserAccount")]
    public class UserAccount
    {
        [Key]
        [Display(Name ="User Id")]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = ("First Name can't be blank"))]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "First Name must be 1 - 10 characters")]
        [Column(TypeName = "nvarchar")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = ("Last Name can't be blank"))]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Last Name must be 1 - 10 characters")]
        [Column(TypeName = "nvarchar")]
        public string LastName { get; set; }
        [Display(Name ="Full Name")]
        [Column(TypeName = "nvarchar")]
        public string FullName { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = ("Phone can't be blank"))]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Phone must be 8 - 12 number")]
        [RegularExpression(@"^[0-9]{8,12}", ErrorMessage = "Phone must be by number")]

        public string Phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = ("Email can't be blank"))]
        [RegularExpression(@"\\w{3,30}@([a-z0-9]{3,10}\\.){1,2}[a-z]{2,3}", ErrorMessage = "Email must be in valid form(Ex: abc@edf.com")]

        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = ("Password can't be blank"))]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#&()–[{}]:;',?/*~$^+=<>]).{8,20}$",
        ErrorMessage = "Password must contains at least 1 digit[0-9]," +
            " 1 lowercase[a-z]," +
            " 1 uppercase[A-Z]," +
            "1 special character like !@#," +
            " 8 - 20 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "Confirm Password must be the same as Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age can't be blank")]
        [Range(18, 120)]
        public int Age { get; set; }
        [Display(Name = "Natinal Identity Card")]
        [Required(ErrorMessage = "Natinal Identity Card can't be blank")]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "NIC must be 8 - 13 characters")]
        public string NIC { get; set; }
        public UserAccount() { 
        FullName = FirstName + " " + LastName;
        }
    }
    [Table("Operator")]
    public class Operator
    {
        [Key]
        [Display(Name ="Operator Id")]
        [RegularExpression(@"^AIR\\d{4}||BUS\\d{4}$")]
        public string OperatorId { get; set; }
        [Display(Name = "Operator Name")]
        [Required(ErrorMessage = ("Operator Name can't be blank"))]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Operator Name must be 1 - 20 characters")]
        [Column(TypeName = "nvarchar")]
        public string OperatorName { get; set; }
        [Display(Name = "From City")]
        [Required(ErrorMessage = ("From can't be blank"))]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "From must be 1 - 20 characters")]
        [Column(TypeName ="nvarchar")]
        public string FromOperator { get; set; }
        [Display(Name = "To City")]
        [Required(ErrorMessage = ("To can't be blank"))]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "To must be 1 - 20 characters")]
        [Column(TypeName = "nvarchar")]
        public string ToOperator { get; set; }
        [Display(Name = "Decription")]
        [Required(ErrorMessage = ("Decription can't be blank"))]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Decription must be 1 - 300 characters")]
        [Column(TypeName = "nvarchar")]
        public string Decription { get; set; }
        [Display(Name = "Rating Star")]
        [Range(5,1,ErrorMessage ="Rating Star must 1 - 5 stars")]
        public int Rating { get; set; }
    }
    [Table("Transportaion")]
    public class Transportation
    {
        [Key]
        [Display(Name ="Trans Id")]
        [RegularExpression(@"^AVN\\d{3}||BVN\\d{3}$")]
        public string TransId { get; set; }
        [Display(Name = "Trans Name")]
        [Required(ErrorMessage = ("Trans Name can't be blank"))]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Trans Name must be 1 - 100 characters")]
        [Column(TypeName = "nvarchar")]
        public string TransName { get; set; }
        [Display(Name = "Seat Capacity")]
        [Required(ErrorMessage = ("Seat Capacity can't be blank"))]
        [Range(50,5)]
        public int SeatingCapacity { get; set; }
    }
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [Display(Name ="Ticket Id")]
        [RegularExpression(@"^A\\d{4}||B\\d{4}$")]
        public string TicketId { get; set; }
        [ForeignKey("Operator")]
        public virtual string OperatorId { get; set; }
        public Operator Operator { get; set; }
        [Column(TypeName = "nvarchar")]
        public string From { get; set; }
        [Column(TypeName = "nvarchar")]
        public string To { get; set; }
        [Display(Name ="Time Start")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Time Start can't be blank")]
        public string TimeStart { get; set; }
        [Display(Name ="Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage ="Price can't be blank")]
        public float Price { get; set; }
        [Display(Name = "Ticket Seat")]
        [RegularExpression(@"^\\W{1}\\d{1}$")]
        [ForeignKey("TransId")]
        public virtual string TransTicket { get; set; }
        public Transportation TransId { get; set; }

        public string TicketSeat { get; set; }
    }
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [Display(Name = "Booking Id")]

        public int BookingId { get; set; }
        [ForeignKey("UserAccount")]
        public virtual int UserId { get; set; }
        public UserAccount UserAccount { get; set; }

        [Column(TypeName = "nvarchar")]
        public  string BookingUserName { get; set; }

        public string BookingPhone { get; set; }

        public string BookingEmail { get; set; }
        [ForeignKey("Ticket")]
        public virtual string BookingTicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
    [Table("ThayHuan")]
    public class ThayHuan
    {
        [Key]
        public int ThayHuanId { get;set; }
        public string ThayHuanName { get; set;}
    }

}
