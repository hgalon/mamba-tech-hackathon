using Dapper;
using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HackathonTotvs.Service.Respository
{
    public class CargoRepository : GenericRepository<Cargo>, ICargo
    {
        public CargoRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }

        public async Task<IEnumerable<dynamic>> GetForId(int id)
        {

            string query = @"select H.id, H.titulo habilidade,CA.url_curso, CA.descricao_curso,CA.desejavel,
            (CASE WHEN CA.nivel = 1 
            THEN 'Básico'
            WHEN CA.nivel = 2 THEN 'Intermediário'
            WHEN CA.nivel = 3 THEN 'Avançado'
            ELSE 'Não se aplica'
            END) nivel, ca.nivel cod_nivel, c.meses_experiencia, c.descricao,
            H.id_tipo_habilidade
            from tb_cargo C
            inner join tb_cargo_habilidade CA on CA.id_cargo = C.id
            inner join tb_habilidade H on H.id = CA.id_habilidade where C.id = @Id";


            return await _conexao.QueryAsync(query, new { Id = id });
        }

        public async Task<dynamic> GetDetailForId(int id)
        {

            string query = @"select C.*, 
            (select H.titulo from tb_cargo_habilidade CG
            inner join tb_habilidade H on H.id = CG.id_habilidade where CG.id_cargo = C.id and H.id_tipo_habilidade = 4
            ) idioma ,
            (select top 1 H.titulo from tb_cargo_habilidade CG
            inner join tb_habilidade H on H.id = CG.id_habilidade where CG.id_cargo = C.id and H.id_tipo_habilidade = 1
            ) formacao 
            from tb_cargo C where C.id = @Id";


            return await _conexao.QueryAsync(query, new { Id = id });
        }
    }
}
