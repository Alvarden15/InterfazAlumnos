using InterfazAlumnos.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Common.Request;
using GraphQL.Client;

namespace InterfazAlumnos.Consumers{
    public class AlumnoConsumer{
        private readonly GraphQLClient cliente;

        public AlumnoConsumer(GraphQLClient c){
            cliente =c;
        }

        public async Task<List<Alumno>> ListadoUsuarios(){
            var query= new GraphQLRequest{
                Query=@"
                {
                    alumnos{
                        id
                        nombre
                        apellido
                        
                    }
                }
                "
            };
            var response= await cliente.PostAsync(query);

            return response.GetDataFieldAs<List<Alumno>>("alumnos");
        }
        /*
        
         */
        
        public async Task<Alumno> BuscarAlumno(int? buscar){
            var query= new GraphQLRequest{
                Query=@"
                query buscaralumno($id:Int){
                    alumno(id:$id){
                        id
                        nombre
                        apellido
                        edad
                    }
                }
                ",
                Variables=new{
                    id=buscar
                }
            };
            var response=await cliente.PostAsync(query);
            return response.GetDataFieldAs<Alumno>("alumno");
        }
        /*
        
         */
        
        public async Task<List<Casa>> ListadoCasas(){
            var query= new GraphQLRequest{
                Query=@"
                query listacasas{
                    casas{
                        id
                        nombre
                        direccion
                        
                    }
                }
                "
            };

            var response= await cliente.PostAsync(query);
            return response.GetDataFieldAs<List<Casa>>("casas");
        }


        public async Task<Casa> Casa(int? buscado){
            var query= new GraphQLRequest{
                Query=@"
                query buscarcasa($busca: Int){
                    casa(id: $busca){
                        id
                        nombre
                        direccion
                        precio
                    }
                }
                ",
                Variables=new{
                    busca=buscado
                }
            };

            var response=await cliente.PostAsync(query);
            return response.GetDataFieldAs<Casa>("casa");
        }
    }
}