using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClassLibrary.DomainContext dctx = new ClassLibrary.DomainContext())
            {
                try
                { 
                    //ClassLibrary.ProfileDet pd = new ClassLibrary.ProfileDet();
                    //pd.ItemName = "TEST";
                    //pd.ItemDescription = "";
                    //pd.ItemType = "";
                    //pd.ItemImage = null;
                    //pd.Gender = ClassLibrary.Gender.Male;
                    //ClassLibrary.GeneralTopics gt = new ClassLibrary.GeneralTopics();
                    //gt.TopicName = "Testopic";
                    //pd.InterestedTopicChecks.Add(gt);
                    //dctx.ProfDets.Add(pd);
                    //dctx.SaveChanges();

                    List<ClassLibrary.GeneralTopics> gtl = new List<ClassLibrary.GeneralTopics>();
                    ClassLibrary.GeneralTopics gt = new ClassLibrary.GeneralTopics();
                    gt.TopicName = "Testopic";
                    gtl.Add(gt);
                    ClassLibrary.ProfileDet pdb = new ClassLibrary.ProfileDet("TESTB", "TESTD", "TESTT", ClassLibrary.Gender.Male, null,gtl);
                    dctx.ProfDets.Add(pdb);
                    dctx.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                          Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)//DbEntityValidationException ex)
                {
                    Console.WriteLine(ex.Message.ToString() + ex.Message.ToString());
                }
            }
        }
        
    }
}
