using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP.Код
{
    public class QUERY
    {

        public int id { get; set; }

        public string Name { get; set; }

        public int idClient { get; set; }

        public int idModule { get; set; }

        public int idOrder { get; set; }

        //public string NameClient { get; set; }

        //public string NameModule { get; set; }

        //public string NameOrder { get; set; }

        public int statusid { get; set; }

        public int UserID { get; set; }

        public List<GroupBox> groupBoxes { get; set; }

        public GroupBox group { get; set; }

        public DataGridView Grid { get; set; }

        public bool update;

        public QUERY()
        {

        }

        public QUERY(bool Up_Ins)
        {
            update = Up_Ins;
        }

        public QUERY(string Name)
        {
            this.Name = Name;
        }

        public int FindClientID() //Поиск id номера по имени
        {
            using (var Connect = new Connect())
            {
                var id = Connect.NameClients.Where(b => b.Name == Name).Select(c => c.Id).FirstOrDefault();
                this.idClient = id;
                return id;

            }

        }

        public int FindModuleID() //Поиск id номера по имени
        {
            using (var Connect = new Connect())
            {
                var id = Connect.NameModules.Where(b => b.NameModule == Name).Select(c => c.Id).FirstOrDefault();
                this.idModule = id;
                return id;

            }

        }

        public void updateClient(GroupBox control) //Редактирование Заказчика
        {
            List<Control> list = ListMethod(control);
            FindStatus(Поиск("ADDStatusContract", list));


            using (var Connect = new Connect())
            {
                var cl = Connect.NameClients.Where(c => c.Id == idClient);

                cl.FirstOrDefault().Name = Поиск("ADDFullName", list);
                cl.FirstOrDefault().ShortName = Поиск("ADDShrtName", list);
                cl.FirstOrDefault().Contract_Num = Поиск("ADDNumberContract", list);

                var LogInfo = new H_CYKP_LogInfo()
                {
                    Name = Поиск("ADDFullName", list),
                    srtName = Поиск("ADDShrtName", list),
                    StatusID = statusid,                    
                    FactDate = DateTime.Now,

                };

                Connect.LogInfos.Add(LogInfo);
                Connect.SaveChanges();

                var log = new List<H_CYKP_Log>()
                { 
                    new H_CYKP_Log { Date = Convert.ToDateTime(Поиск("ADDDateStart",list)),TypeModeid = 1, ClientId = idClient, LogInfoID = LogInfo.Id,
                            StatusProductId = statusid,    UserId = UserID,  DateTypeID = 1  },

                    new H_CYKP_Log { Date = Convert.ToDateTime(Поиск("ADDDateContract",list)),  TypeModeid = 1,ClientId = idClient,LogInfoID = LogInfo.Id,
                            StatusProductId = statusid,  UserId = UserID, DateTypeID = 2 },

                    new H_CYKP_Log { Date = Convert.ToDateTime(Поиск("ADDDateContractEnd",list)),   TypeModeid = 1,ClientId = idClient,LogInfoID = LogInfo.Id,
                            StatusProductId = statusid, UserId = UserID, DateTypeID = 3  }
                };


                Connect.Logs.Add(log[0]);
                Connect.Logs.Add(log[1]);
                Connect.Logs.Add(log[2]);

                Connect.SaveChanges();

            };
        }

        public void updateOrder(GroupBox control) //Редактирование Заказчика
        {
            List<Control> list = ListMethod(control);
            FindStatus(Поиск("ADDprjStatus", list));

            using (var Connect = new Connect())
            {
                var order = Connect.NameProjects.Where(c => c.Id == idOrder);

                order.FirstOrDefault().NameProject = Поиск("ADDTBNameProject", list);
                order.FirstOrDefault().Count = Поиск("ADDTBОбъемЗаказа", list);

                var LogInfo = new H_CYKP_LogInfo()
                {
                    Name = Поиск("ADDTBNameProject", list),
                    Count = Поиск("ADDTBОбъемЗаказа", list),
                    StatusID = statusid,
                    FactDate = DateTime.Now,

                };

                Connect.LogInfos.Add(LogInfo);
                Connect.SaveChanges();

                var Log = new H_CYKP_Log()

                {
                    Date = Convert.ToDateTime(Поиск("ADDDateProject", list)),
                    ProjectId = idOrder,
                    ClientId = idClient,
                    LogInfoID = LogInfo.Id,
                    TypeModeid = 2,
                    StatusProductId = statusid,
                    UserId = UserID,
                    DateTypeID = 1
                };

                Connect.Logs.Add(Log);
                Connect.SaveChanges();

            };
        }

        public void UpdateModule(GroupBox control)
        {

            List<Control> list = ListMethod(control);
            FindStatus(Поиск("ADDStatusModule", list));

            using (var Connect = new Connect())
            {
                var Module = Connect.NameModules.Where(c => c.Id == idModule);

                Module.FirstOrDefault().NameModule = Поиск("ADDNameModule", list);
                Module.FirstOrDefault().CountModule = Поиск("ADDCountModule", list);

                var LogInfo = new H_CYKP_LogInfo()
                {
                    Name = Поиск("ADDNameModule", list),
                    Count = Поиск("ADDCountModule", list),
                    StatusID = statusid,
                    FactDate = DateTime.Now,

                };

                Connect.LogInfos.Add(LogInfo);
                Connect.SaveChanges();

                var Log = new H_CYKP_Log()
                {
                    Date = Convert.ToDateTime(Поиск("ADDDateCreate", list)),
                    ProjectId = idOrder,
                    ClientId = idClient,
                    ModuleID = idModule,
                    LogInfoID = LogInfo.Id,
                    TypeModeid = 3,
                    StatusProductId = statusid,
                    UserId = UserID,
                    DateTypeID = 1
                };
                Connect.Logs.Add(Log);
                Connect.SaveChanges();
            }

        }

        public int FindOrderID() //Поиск id номера по имени
        {
            using (var Connect = new Connect())
            {
                var id = Connect.NameProjects.Where(b => b.NameProject == Name).Select(c => c.Id).FirstOrDefault();
                this.idOrder = id;
                return id;
            }

        }
        public void FindStatus(string name)
        {
            using (var Connect = new Connect())
            {
                var id = Connect.StatusProducts.Where(b => b.Name == name).Select(c => c.Id).FirstOrDefault();
                this.statusid = id;
            }
        }

        string Поиск(string name, List<Control> list) //Функция поиска по имени элемента его свойства TEXT
        {
            return list.Where(c => c.Name == name).Select(b => b.Text).FirstOrDefault();
        }

        public GroupBox Поиск(List<GroupBox> GB, string name)
        {
            var obj = GB.Where(c => c.Name == name).FirstOrDefault();

            return obj;
        }

        public void addClient(GroupBox control) //Группбокс где будут взяты все элементы
        {
            List<Control> list = ListMethod(control);
            FindStatus(Поиск("ADDStatusContract", list));
            using (var con = new Connect())
            {
                var LogInfo = new H_CYKP_LogInfo()
                {
                    Name = Поиск("ADDFullName", list),
                    srtName = Поиск("ADDShrtName", list),
                    StatusID = statusid,
                    FactDate = DateTime.Now,

                };


                con.LogInfos.Add(LogInfo);
                con.SaveChanges();
                //MessageBox.Show(con.LogInfos.OrderByDescending(v => v.Id).Select(c => c.Id).FirstOrDefault().ToString());

                var cl = new H_CYKP_Name_Client() //Добавление в таблицу Client
                {
                    Name = Поиск("ADDFullName", list),
                    ShortName = Поиск("ADDShrtName", list),
                    Contract_Num = Поиск("ADDNumberContract", list),

                    Log = new List<H_CYKP_Log> //Добавление в таблицу Log
                    {
                       new H_CYKP_Log  { Date = Convert.ToDateTime(Поиск("ADDDateStart",list)),TypeModeid = 1, LogInfoID = LogInfo.Id,
                            StatusProductId = statusid,    UserId = UserID,  DateTypeID = 1  },

                       new H_CYKP_Log { Date = Convert.ToDateTime(Поиск("ADDDateContract",list)),  TypeModeid = 1,LogInfoID = LogInfo.Id,
                            StatusProductId = statusid,  UserId = UserID, DateTypeID = 2 },

                       new H_CYKP_Log { Date = Convert.ToDateTime(Поиск("ADDDateContractEnd",list)),   TypeModeid = 1,LogInfoID = LogInfo.Id,
                            StatusProductId = statusid, UserId = UserID, DateTypeID = 3  }
                    }
                };


                con.NameClients.Add(cl);
                con.SaveChanges();

            };

        }

        public void addOrder(GroupBox control)
        {
            List<Control> list = ListMethod(control);
            Name = Поиск("ADDCBClientInOrder", list);

            FindStatus(Поиск("ADDprjStatus", list));
            FindClientID();
            using (var con = new Connect())
            {
                var LogInfo = new H_CYKP_LogInfo()
                {
                    Name = Поиск("ADDTBNameProject", list),
                    Count = Поиск("ADDTBОбъемЗаказа", list),
                    StatusID = statusid,
                    FactDate = DateTime.Now

                };

                con.LogInfos.Add(LogInfo);
                con.SaveChanges();


                var order = new H_CYKP_Name_Project()
                {
                    NameProject = Поиск("ADDTBNameProject", list),
                    Count = Поиск("ADDTBОбъемЗаказа", list),
                    ClientId = idClient,
                    Log = new List<H_CYKP_Log>
                    {
                        new H_CYKP_Log{Date = Convert.ToDateTime(Поиск("ADDDateProject", list)),  ClientId = idClient, LogInfoID = LogInfo.Id,
                            TypeModeid = 2,StatusProductId = statusid, UserId = UserID,DateTypeID = 1}
                    }

                };


                con.NameProjects.Add(order);
                con.SaveChanges();
            };

        }

        public void addModule(GroupBox control)
        {
            List<Control> list = ListMethod(control);
            Name = Поиск("ADDCBClentInModule", list);
            FindClientID();
            Name = Поиск("ADDCBOrderinModule", list);
            FindOrderID();

            FindStatus(Поиск("ADDStatusModule", list));
            
            
            using (var con = new Connect())

            {
                var LogInfo = new H_CYKP_LogInfo()
                {
                    Name = Поиск("ADDNameModule", list),
                    Count = Поиск("ADDCountModule", list),
                    StatusID = statusid,
                    FactDate = DateTime.Now

                };

                con.LogInfos.Add(LogInfo);
                con.SaveChanges();


                var modl = new H_CYKP_NameModule()
                {
                    NameModule = Поиск("ADDNameModule", list),
                    CountModule = Поиск("ADDCountModule", list),
                    ProjectId = idOrder,

                    Log = new List<H_CYKP_Log>()
                    {
                         new H_CYKP_Log{Date = Convert.ToDateTime(Поиск("ADDDateCreate", list)), ClientId = idClient, ProjectId = idOrder, LogInfoID = LogInfo.Id,
                            TypeModeid = 3,StatusProductId = statusid, UserId = UserID,DateTypeID = 1}
                    }

                };

                con.NameModules.Add(modl);
                con.SaveChanges();
            };
        }

        private List<Control> ListMethod(GroupBox control)
        {
            var list = new List<Control>();


            foreach (Control c in control.Controls) //Добавляет все элементы в группбоксе, которые начинаются на ADD
                if (c.Name.StartsWith("ADD"))
                    list.Add(c); //Добавляем в МАССИВ

            return list;
        }

        public List<string> GetInfoClient() //Получаем информацию о клиенте
        {
            var lists = new List<string>();
            using (var connect = new Connect())
            {
                var list = (from clients in connect.NameClients
                            join logs in connect.Logs on clients.Id equals logs.ClientId
                            join status in connect.StatusProducts on logs.StatusProductId equals status.Id
                            where clients.Id == this.idClient && logs.TypeModeid == 1
                            select new { H_CYKP_Name_Client = clients, H_CYKP_StatusProduct = status, H_CYKP_Log = logs })

                      .ToList();

                if (list.Count == 0)
                    return lists;

                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_Name_Client.Name).FirstOrDefault()); // имя клиента
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_Name_Client.ShortName).FirstOrDefault()); // короткое имя клиента
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_Name_Client.Contract_Num).FirstOrDefault()); //номер контракта
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_StatusProduct.Name).FirstOrDefault()); //Имя статуса

                for (int i = 1; i < 4; i++)
                    addDate(i);      

                void addDate(int idtypedate)
                {
                    lists.Add(list.Where(c => c.H_CYKP_Log.DateTypeID == idtypedate).OrderByDescending(v => v.H_CYKP_Log.Id).Select(b => b.H_CYKP_Log.Date).FirstOrDefault().ToString());
                }

                return lists;
            }
        }

        public List<string> GetInfoOrder() //Получаем информацию о заказе
        {
            var lists = new List<string>();
            using (var connect = new Connect())
            {
                var list = (from order in connect.NameProjects

                            join log in connect.Logs on order.Id equals log.ProjectId
                            join stat in connect.StatusProducts on log.StatusProductId equals stat.Id
                            join Client in connect.NameClients on order.ClientId equals Client.Id
                            where
                            //log.ClientId == idClient &&
                            order.NameProject == Name && log.TypeModeid == 2 && log.DateTypeID == 1
                            select new { H_CYKP_Name_Client = Client, H_CYKP_Log = log, H_CYKP_Name_Project = order, H_CYKP_StatusProduct = stat })

                    .ToList();

                if (list.Count == 0)
                    return lists;
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Name_Client.Id).Select(c => c.H_CYKP_Name_Client.Name).FirstOrDefault()); // Имя Клиента
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Name_Project.Id).Select(c => c.H_CYKP_Name_Project.NameProject).FirstOrDefault()); // Имя заказа
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_Name_Project.Count).FirstOrDefault()); //Количество в заказе
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_Log.Date).FirstOrDefault().ToString()); //Дата
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_StatusProduct.Name).FirstOrDefault());//Статус          
                return lists;
            }
        }


        public List<string> GetInfoModule() //Получаем информацию о заказе
        {
            var lists = new List<string>();
            using (var connect = new Connect())
            {
                var list = (from Module in connect.NameModules

                            join log in connect.Logs on Module.Id equals log.ModuleID
                            join stat in connect.StatusProducts on log.StatusProductId equals stat.Id
                            join order in connect.NameProjects on Module.ProjectId equals order.Id
                            join client in connect.NameClients on order.ClientId equals client.Id
                            where
                            //log.ClientId == idClient && log.ProjectId == idOrder &&
                            Module.NameModule == Name && log.TypeModeid == 3 && log.DateTypeID == 1
                            select new { H_CYKP_Name_Client = client, H_CYKP_Name_Project = order, H_CYKP_Log = log, H_CYKP_NameModule = Module, H_CYKP_StatusProduct = stat })
                   .ToList();

                if (list.Count == 0)
                    return lists;

                lists.Add(list.Select(c => c.H_CYKP_Name_Client.Name).FirstOrDefault()); //Имя заказчика
                lists.Add(list.Select(c => c.H_CYKP_Name_Project.NameProject).FirstOrDefault()); //Имя заказа
                lists.Add(list.Select(c => c.H_CYKP_NameModule.NameModule).FirstOrDefault()); //Имя Модуля
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_NameModule.CountModule).FirstOrDefault()); //Количество в модуле
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_Log.Date).FirstOrDefault().ToString()); //Дата создание модуля
                lists.Add(list.OrderByDescending(b => b.H_CYKP_Log.Id).Select(c => c.H_CYKP_StatusProduct.Name).FirstOrDefault()); //СтатусМодуля



            }

            return lists;
        }

        public void ListClients(DataGridView Grid) //Вывод списка всех заказчиков
        {
            Grid.DataSource = null;

            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameClients.OrderByDescending(c => c.Id)
                           select new { c.Name };

                Grid.DataSource = list.ToList();
                Grid.ClearSelection();
            }
        }

        public void ListClients(DataGridView Grid, string name)//Вывод определнного заказчика
        {
            Grid.DataSource = null;

            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameClients.Where(c => c.Name == name).OrderByDescending(c => c.Id)
                           select new { c.Name };
                Grid.DataSource = list.ToList();
                Grid.ClearSelection();
            }

            var Qr = new QUERY();
            this.idClient = Qr.FindClientID();
        }

        public void ListOrder(DataGridView Grid) //Вывод списка всех заказчиков
        {
            Grid.DataSource = null;

            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameProjects.Where(b => b.ClientId == idClient).OrderByDescending(c => c.Id)
                           select new { c.NameProject };

                Grid.DataSource = list.ToList();
                Grid.ClearSelection();
            }

        }

        public void ListOrder(DataGridView Grid, string name) //Вывод списка всех заказчиков
        {
            Grid.DataSource = null;

            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameProjects.Where(b => b.ClientId == idClient && b.NameProject == name).OrderByDescending(c => c.Id)
                           select new { c.NameProject };

                Grid.DataSource = list.ToList();
                Grid.ClearSelection();
            }

        }

        public void ListModule(DataGridView Grid) //Вывод списка всех заказчиков
        {
            Grid.DataSource = null;

            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameModules.Where(b => b.ProjectId == idOrder).OrderByDescending(c => c.Id)
                           select new { c.NameModule };

                Grid.DataSource = list.ToList();
                Grid.ClearSelection();
            }

        }

        public void ListModule(DataGridView Grid, string name) //Вывод списка всех заказчиков
        {
            Grid.DataSource = null;

            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameModules.Where(b => b.ProjectId == idOrder && b.NameModule == name).OrderByDescending(c => c.Id)
                           select new { c.NameModule };

                Grid.DataSource = list.ToList();
                Grid.ClearSelection();
            }

        }

        public void getLogOrder()
        {
            FindOrderID();
            using (var connect = new Connect())
            {
                var list = (from Order in connect.NameProjects

                            join log in connect.Logs on Order.Id equals log.ProjectId                            
                            join InfoLog in connect.LogInfos on log.LogInfoID equals InfoLog.Id
                            join stat in connect.StatusProducts on log.StatusProductId equals stat.Id
                            join user in connect.Users on log.UserId equals user.Id
                            join usSt in connect.StatusUsers on user.StatusId equals usSt.Id

                            where Order.Id == idOrder && log.Module == null

                            select new {
                              Факт_Дата = InfoLog.FactDate
                            , Заказ = InfoLog.Name
                            , Статус  = stat.Name
                            , Дата = log.Date
                            , Количество_в_заказе = InfoLog.Count
                            , Пользователь = user.UserName
                            , Статус_Пользователя = usSt.Status })
                   .ToList();

                Grid.DataSource = list;
            }


        }

        public void getLogClient()
        {
            FindClientID();
            using (var connect = new Connect())
            {
                var list = (from Client in connect.NameClients

                            join log in connect.Logs on Client.Id equals log.ClientId
                            join InfoLog in connect.LogInfos on log.LogInfoID equals InfoLog.Id
                            join stat in connect.StatusProducts on log.StatusProductId equals stat.Id
                            join user in connect.Users on log.UserId equals user.Id
                            join usSt in connect.StatusUsers on user.StatusId equals usSt.Id

                            where Client.Id == idClient && log.Module == null && log.ProjectId == null

                            select new { Фактическая_дата = InfoLog.FactDate
                                        , Имя_Заказчика = InfoLog.Name
                                        , Статус = stat.Name
                                        , Дата = log.Date
                                        , Пользователь = user.UserName
                                        , Статус_пользователя = usSt.Status })
                   .ToList();

                Grid.DataSource = list;
            }


        }

        public void getLogModule()
        {
            FindModuleID();
            using (var connect = new Connect())
            {
                var list = (from Module in connect.NameModules

                            join log in connect.Logs on Module.Id equals log.ModuleID
                            join InfoLog in connect.LogInfos on log.LogInfoID equals InfoLog.Id
                            join stat in connect.StatusProducts on log.StatusProductId equals stat.Id
                            join user in connect.Users on log.UserId equals user.Id
                            join usSt in connect.StatusUsers on user.StatusId equals usSt.Id

                            where Module.Id == idModule

                            select new {
                              Факт_Дата = InfoLog.FactDate
                            , Имя_Модуля = InfoLog.Name
                            , Статус = stat.Name
                            , Дата = log.Date
                            , Количество_в_модуле = InfoLog.Count
                            , Пользователь = user.UserName
                            , Статус_пользователя = usSt.Status })
                   .ToList();

                Grid.DataSource = list;
            }


        }

        delegate H_CYKP_Document SaveMeth();

        public void SaveFile(int i, string path)
        {
            using (var con = new Connect())
            {
                var list = new List<SaveMeth> { Client, Order, Module };
                con.Documents.Add(list[i]());
                con.SaveChanges();

                H_CYKP_Document Client()
                {
                    FindClientID();

                    var document = new H_CYKP_Document()
                    {
                        NamePath = path,

                        LogDocument = new List<H_CYKP_LogDocuments>()
                        {
                            new H_CYKP_LogDocuments {Date = DateTime.Now, UserId = 2, ClientId = idClient, TypeModeid = 1 }
                        }
                    };
                    return document;
                }

                H_CYKP_Document Order()
                {
                    FindOrderID();
                    var document = new H_CYKP_Document()
                    {
                        NamePath = path,

                        LogDocument = new List<H_CYKP_LogDocuments>()
                        {
                            new H_CYKP_LogDocuments {Date = DateTime.Now, UserId = 2,  OrderId = idOrder, TypeModeid = 2 }
                        }
                    };
                    return document;
                }

                H_CYKP_Document Module()
                {
                    FindModuleID();
                    var document = new H_CYKP_Document()
                    {
                        NamePath = path,

                        LogDocument = new List<H_CYKP_LogDocuments>()
                        {
                            new H_CYKP_LogDocuments {Date = DateTime.Now, UserId = 2,  ModuleID = idModule, TypeModeid = 3}
                        }
                    };
                    return document;
                }



            }
        }
    }
}
