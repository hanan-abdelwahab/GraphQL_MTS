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
                    Name="Fotouh1233121"

                }
            };


            var schema = GraphQL<HR.Logic.HRContext>.CreateDefaultSchema(() => data);
            schema.AddType<Employee>().AddAllFields();
            //
            schema.AddListField("Employees", (db) => db.Employees.AsQueryable());
            schema.Complete();
            GraphQL = new GraphQL<HR.Logic.HRContext>(schema);

        }

    }
}