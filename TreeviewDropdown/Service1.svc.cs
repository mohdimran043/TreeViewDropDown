using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace TreeviewDropDown
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
       public class Service1 : IService1
    {
        public List<DllItem> GetAllItems()
        {

            Items objItems = new Items();
            List<DllItem> ObjDDLItems = new List<DllItem>();

            DllItem item1 = new DllItem();
            item1.Name = "Odisha";
            item1.ID = 0;

            ObjDDLItems.Add(item1);

            DllItem item11 = new DllItem();
            item11.Name = "- Mayurbhanj";
            item11.ID = 1;

            ObjDDLItems.Add(item11);

            DllItem item12 = new DllItem();
            item12.Name = "- Keonjhar";
            item12.ID = 2;

            ObjDDLItems.Add(item12);

            DllItem item13 = new DllItem();
            item13.Name = "- Khorda";
            item13.ID = 3;

            ObjDDLItems.Add(item13);


            DllItem item2 = new DllItem();
            item2.Name = "Chennai";
            item2.ID = 0;

            ObjDDLItems.Add(item2);

            DllItem item21 = new DllItem();
            item21.Name = "- Mapurbhanj";
            item21.ID = 1;


            ObjDDLItems.Add(item21);

            DllItem item22 = new DllItem();
            item22.Name = " -B";
            item22.ID = 2;

            ObjDDLItems.Add(item22);

            DllItem item23 = new DllItem();
            item23.Name = " -C";
            item23.ID = 3;

            ObjDDLItems.Add(item23);

            objItems.ItemList = ObjDDLItems;

            return (ObjDDLItems);
        }

        public List<TreeItem> GetAllTreeviewItems()
        {
            List<TreeItem> ObjListTreeItems = new List<TreeItem>();
            {

                //Item 1
                TreeItem objTreeItemA = new TreeItem();
                {
                    objTreeItemA.text = "India";
                    objTreeItemA.id = "1-0";
                    objTreeItemA.expanded = true;
                    List<MyItem> objListMyItem = new List<MyItem>();
                    {
                        MyItem objMyItem1 = new MyItem();
                        objMyItem1.text = "Delhi";
                        objMyItem1.id = "1-1";
                        objListMyItem.Add(objMyItem1);


                        MyItem objMyItem2 = new MyItem();
                        objMyItem2.text = "Mumbai";
                        objMyItem2.id = "1-2";
                        objListMyItem.Add(objMyItem2);

                        MyItem objMyItem3 = new MyItem();
                        objMyItem3.text = "Chandigarh";
                        objMyItem3.id = "1-3";
                        objListMyItem.Add(objMyItem3);
                    }
                    objTreeItemA.items = objListMyItem;
                }
                ObjListTreeItems.Add(objTreeItemA);


                TreeItem objTreeItemB = new TreeItem();
                {
                    objTreeItemB.text = "USA";
                    objTreeItemB.id = "2-0";
                    objTreeItemB.expanded = true;
                    List<MyItem> objListMyItem = new List<MyItem>();
                    {
                        MyItem objMyItem1 = new MyItem();
                        objMyItem1.text = "California";
                        objMyItem1.id = "2-1";
                        objListMyItem.Add(objMyItem1);


                        MyItem objMyItem2 = new MyItem();
                        objMyItem2.text = "Texas";
                        objMyItem2.id = "2-2";
                        objListMyItem.Add(objMyItem2);

                        MyItem objMyItem3 = new MyItem();
                        objMyItem3.text = "Florida";
                        objMyItem3.id = "2-3";
                        objListMyItem.Add(objMyItem3);

                        MyItem objMyItem4 = new MyItem();
                        objMyItem4.text = "DC, Washington";
                        objMyItem4.id = "2-4";
                        objListMyItem.Add(objMyItem4);
                    }
                    objTreeItemB.items = objListMyItem;
                }
                ObjListTreeItems.Add(objTreeItemB);


                TreeItem objTreeItemC = new TreeItem();
                {
                    objTreeItemC.text = "France";
                    objTreeItemC.id = "3-0";
                    objTreeItemC.expanded = true;
                }
                ObjListTreeItems.Add(objTreeItemC);

                TreeItem objTreeItemD = new TreeItem();
                {
                    objTreeItemD.text = "England";
                    objTreeItemD.id = "4-0";
                    objTreeItemD.expanded = true;
                }
                ObjListTreeItems.Add(objTreeItemD);
            }
            
            return (ObjListTreeItems);            
        }
    }
}
