using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ColourFusion.BL;
using System.Windows.Forms;


namespace ColourFusion.DL
{
    class UserDL
    {
        private static LinkedList<User> UsersList = new LinkedList<User>();

        private static List<Employee> EmployeesList = new List<Employee>();

        private static List<Rider> RidersList = new List<Rider>();

        public static LinkedList<User> UsersList1 { get => UsersList; set => UsersList = value; }
        public static List<Employee> EmployeesList1 { get => EmployeesList; set => EmployeesList = value; }
        internal static List<Rider> RidersList1 { get => RidersList; set => RidersList = value; }

        public static void AddOrderInList(User User)
        {
            UsersList.AddLast(User);
        }

        public static void EditRider(Rider Previous, Rider Updated)
        {
            /*foreach (Rider r in UsersList)
            {
                if (r.UserID1 == Previous.UserID1 && r.Cnic1 == Previous.Cnic1)
                {
                    r.Name1 = Updated.Name1;
                    r.UserPassword1 = Updated.UserPassword1;
                    r.Type1 = Updated.Type1;
                    r.UserID1 = Updated.UserID1;
                    r.EmailAddress1 = Updated.EmailAddress1;
                    r.ContactNo1 = Updated.ContactNo1;
                    r.Cnic1 = Updated.Cnic1;
                    r.NumberPlate1 = Updated.NumberPlate1;
                    r.VehicleName1 = Updated.VehicleName1;
                    r.VehicleColor1 = Updated.VehicleColor1;
                }
            }*/

            foreach (Rider r in RidersList)
            {
                if (r.UserID1 == Previous.UserID1 && r.Cnic1 == Previous.Cnic1)
                {
                    r.Name1 = Updated.Name1;
                    r.UserPassword1 = Updated.UserPassword1;
                    r.Type1 = Updated.Type1;
                    r.UserID1 = Updated.UserID1;
                    r.EmailAddress1 = Updated.EmailAddress1;
                    r.ContactNo1 = Updated.ContactNo1;
                    r.Cnic1 = Updated.Cnic1;
                    r.NumberPlate1 = Updated.NumberPlate1;
                    r.VehicleName1 = Updated.VehicleName1;
                    r.VehicleColor1 = Updated.VehicleColor1;
                }
            }
        }

        public static void EditEmployee(Employee Previous, Employee Updated)
        {
            /*foreach (Employee r in UsersList)
            {
                if (r.UserID1 == Previous.UserID1 && r.Cnic1 == Previous.Cnic1)
                {
                    r.Name1 = Updated.Name1;
                    r.UserPassword1 = Updated.UserPassword1;
                    r.Type1 = Updated.Type1;
                    r.UserID1 = Updated.UserID1;
                    r.EmailAddress1 = Updated.EmailAddress1;
                    r.ContactNo1 = Updated.ContactNo1;
                    r.Cnic1 = Updated.Cnic1;
                    r.StartShift1 = Updated.StartShift1;
                    r.EndShift1 = Updated.EndShift1;
                }
            }*/

            foreach (Employee r in EmployeesList)
            {
                if (r.UserID1 == Previous.UserID1 && r.Cnic1 == Previous.Cnic1)
                {
                    r.Name1 = Updated.Name1;
                    r.UserPassword1 = Updated.UserPassword1;
                    r.Type1 = Updated.Type1;
                    r.UserID1 = Updated.UserID1;
                    r.EmailAddress1 = Updated.EmailAddress1;
                    r.ContactNo1 = Updated.ContactNo1;
                    r.Cnic1 = Updated.Cnic1;
                    r.StartShift1 = Updated.StartShift1;
                    r.EndShift1 = Updated.EndShift1;
                }
            }
        }

        public static void DeleteUserFromList(User user1)
        {
            foreach (User user in UsersList)
            {
                if (user.Cnic1 == user1.Cnic1)
                {
                    UsersList1.Remove(user);
                }
            }
        }

        public static User CheckUser(User u)
        {
            foreach (User user in UsersList)
            {
                if (u.UserID1 == user.UserID1 && u.UserPassword1 == user.UserPassword1)
                {
                    return user;
                }
            }
            return null;
        }

        public static Rider CheckUser(string Id)
        {
            foreach (Rider user in RidersList)
            {
                if (user.UserID1==Id)
                {
                    return user;
                }
            }
            return null;
        }

        public static Manager GetCurrentManager(string u)
        {
            foreach (Manager m in UsersList)
            {
                if (u == m.UserID1)
                {
                    return m;
                }
            }
            return null;
        }

        public static Employee GetCurrentEmployee(string u)
        {
            foreach (Employee m in UsersList)
            {
                if (u == m.UserID1)
                {
                    return m;
                }
            }
            return null;
        }

        public static Rider GetCurrentRider(string u)
        {
            foreach (Rider m in RidersList)
            {
                if (u == m.UserID1)
                {
                    return m;
                }
            }
            return null;
        }

        public static bool ReadEmployeesFromFile()
        {
            bool flag = false;
            var lines = File.ReadAllLines("EmployeesData.csv");
            foreach (var line in lines)
            {
                var values = line.Split(',');
                var Employee = new Employee(values[0], values[1], values[2], values[3], values[4], values[5], values[6], Convert.ToInt32(values[7]), Convert.ToInt32(values[8]));
                UsersList.AddLast(Employee);
                EmployeesList.Add(Employee);
                flag = true;
            }
            if (flag == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ReadRidersFromFile()
        {
            bool flag = false;
            var lines = File.ReadAllLines("RidersData.csv");
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 17)
                {
                    //MessageBox.Show(values[17]);
                    Fuel f = new Fuel(Convert.ToInt32(values[11]), Convert.ToInt32(values[12]), Convert.ToInt32(values[13]), Convert.ToInt32(values[14]), Convert.ToInt32(values[15]), Convert.ToInt32(values[16]), values[17]);
                    Rider r = new Rider(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], f);
                    if (values[17] == values[10])
                    {
                        r.AddFuelInfo(f);
                    }
                    UsersList.AddLast(r);
                    RidersList.Add(r);
                    flag = true;
                }
                else
                {
                    Rider r = new Rider(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10]);
                    UsersList.AddLast(r);
                    RidersList.Add(r);
                    flag = true;
                }

            }
            if (flag == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ReadManagersFromFile()
        {
            bool flag = false;
            var lines = File.ReadAllLines("ManagersData.csv");
            Console.WriteLine(lines.ToString());
            foreach (var line in lines)
            {
                var values = line.Split(',');
                var Manager = new Manager(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
                UsersList.AddLast(Manager);
                flag = true;
            }
            if (flag == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void WriteEmployeeInFile()
        {
            StreamWriter file = new StreamWriter("EmployeesData.csv");
            foreach (Employee c in EmployeesList)
            {
                file.WriteLine(c.UserID1 + "," + c.UserPassword1 + "," + c.Name1 + "," + c.EmailAddress1 + "," + c.ContactNo1 + "," + c.Cnic1 + "," + c.Type1 + "," + c.StartShift1 + "," + c.EndShift1);
            }
            file.Flush();
            file.Close();
        }

        public static void WriteRiderInFile()
        {
            StreamWriter file = new StreamWriter("RidersData.csv");
            foreach (Rider c in RidersList)
            {
                if (c.FuelInfoList1 != null)
                {
                    foreach (Fuel f in c.FuelInfoList1)
                    {
                        file.WriteLine(c.UserID1 + "," + c.UserPassword1 + "," + c.Name1 + "," + c.EmailAddress1 + "," + c.ContactNo1 + "," + c.Cnic1 + "," + c.Type1 + "," + c.VehicleName1 + "," + c.VehicleColor1 + "," + c.NumberPlate1 + "," + c.ID1 + "," + f.Date1 + "," + f.AmountAdded1 + "," + f.Price1 + "," + f.TotalConsumption1 + "," + f.FuelLeft1 + "," + f.AmountSaved1 + "," + f.Id1);
                    }
                }
                else
                {
                    file.WriteLine(c.UserID1 + "," + c.UserPassword1 + "," + c.Name1 + "," + c.EmailAddress1 + "," + c.ContactNo1 + "," + c.Cnic1 + "," + c.Type1 + "," + c.VehicleName1 + "," + c.VehicleColor1 + "," + c.NumberPlate1 + "," + c.ID1);
                }
            }
            file.Flush();
            file.Close();
        }
    }
}
