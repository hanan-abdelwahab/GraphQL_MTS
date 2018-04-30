using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Net;
using HR.Models;
namespace HR.GraphQL
{
    public class HRGraphSchema
    {
        public GraphQL<HR.Logic.HRContext> GraphQL;

        public HRGraphSchema()
        {

            #region Data
            var data = new HR.Logic.HRContext();
            data.Employees = new List<Employee>{

                new HR.Models.Employee()
                {
                    Id="1",
                    Name="Wakeel"

                },
                 new HR.Models.Employee()
                {
                    Id="2",
                    Name="Hanan"

                },
                 new HR.Models.Employee()
                {
                    Id="3",
                    Name="Fotouh"

                }
            }; 
            #endregion

            //Create DefaultSchema from All returned objects
            var schema = GraphQL<HR.Logic.HRContext>.CreateDefaultSchema(() => data);
           

            //Add single types to schema
            schema.AddType<Employee>().AddAllFields();
           
            //Add fields (the query functions) to schema
            schema.AddListField("Employees", (db) => db.Employees.AsQueryable());
            schema.Complete();

            //assign schema to GraphQL object
            GraphQL = new GraphQL<HR.Logic.HRContext>(schema);

        }

    }
}