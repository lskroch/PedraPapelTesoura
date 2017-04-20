using PedraPapelTesoura.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PedraPapelTesoura.Controler
{
   public class ControlerJogo
    {
       //cada grupo pode ter 1 ou mais subgrupos
        public static Jogador StartPartida(List<Grupo> listaGruposJogadores)
        {
            Jogador vencedor = null;
            foreach (Grupo grup in listaGruposJogadores)
            {
                Jogador jogVencd = GetVencedor(grup.ListaSubGrupo);
                if (vencedor == null)
                    vencedor = jogVencd;
                else if (isMaior(jogVencd.Letra, jogVencd.Letra))
                    vencedor = jogVencd;

                Console.WriteLine("grupo "+ grup.Indice+", " + vencedor.ToString());
            }

            Console.WriteLine("Vencedor =" + vencedor.ToString());
            return vencedor;
        }

        //Iteração no subgrupo
        private static Jogador GetVencedor(List<SubGrupo> listSub)
        {
            Jogador jogVencd = null;
            foreach (SubGrupo grup in listSub)
            {
                Jogador jogador = GetJogadorVencedorGrupo(grup.ListaJogadores);
                if (jogVencd == null)
                    jogVencd = jogador;
                else if (isMaior(jogador.Letra, jogVencd.Letra))
                     jogVencd = jogador;

                Console.WriteLine("SubGrupo " + grup.Indice + ", " + jogVencd.ToString());
            }
            return jogVencd;
        }
               
        private static Jogador GetJogadorVencedorGrupo(List<Jogador> lista)
        {
            Jogador vencedor=null;
            foreach (Jogador jogador in lista)
            {
                if (vencedor == null)
                {
                    vencedor = jogador;
                    vencedor.Venceu = true;
                    jogador.Venceu = false;
                }
                else
                {
                    if (isMaior(jogador.Letra,vencedor.Letra ))
                        vencedor = jogador;
                }
            }
            vencedor.Venceu = true;
            return vencedor;
        }

        private static bool isMaior(string A, string B)
        {
            ////As regras são: R vence S; S vence P; e P vence R.
            if (A == "R" && B == "S")
                return true;
            else if (A == "S" && B == "P")
                return true;
            else if (A == "P" && B == "R")
                return true;
            else
                return false;
        }
        public static List<Grupo> RpsGameWinner(string strList) 
        {
            List<Grupo> listGrupoJog = new List<Grupo>();
            if (strList != "")
            {
                //remover os espaços do inicio e final
                strList= strList.Trim();
                //remove /n/r
                strList = string.Join("", Regex.Split(strList, @"(?:\r\n|\n|\r)")).Replace(" ", "").Replace("\t", "");

                //remove o primeiro "[" e o fim "]" da lista
                strList = strList.Substring(1, strList.Length - 1);


                string[] gruposAux = strList.Split(new string[] { "],[[[" }, StringSplitOptions.None);

               
                //reconfigura dos grupos
                for (int i=0; i< gruposAux.Length; i++)
                {
                    //separa os subgrupos de jogadores
                    //]], 

                    Grupo grupo = new Grupo();
                    grupo.Indice = i;

                    string[] subgrup = gruposAux[i].Split(new string[] { "]]," }, StringSplitOptions.None);
                    for (int j = 0; j < subgrup.Length; j++)
                    {

                        if (subgrup[j].Length < 5)
                            continue;

                        SubGrupo subGrupo = new SubGrupo();
                        subGrupo.Indice = j;

                        string strSubgrup = subgrup[j];
                        if (strSubgrup.Length > 0)
                        {
                            string[] jogadores = subgrup[j].Split(new string[] { "],[" }, StringSplitOptions.None);
                            if (jogadores.Length != 2)
                                throw new WrongNumberOfPlayersError("Lista de jogadores mal formada!");

                            //primeiro          segundo
                            //[["DavidE.","R"],["RichardX.","P"]] 
                            
                            Jogador jog1 = new Jogador();
                            jog1.Nome = jogadores[0].Split(',')[0];//recupera o nome do primeiro jogador
                            jog1.Letra = jogadores[0].Split(',')[1];//recupera a LETRA do primeiro jogador

                            //limpa o nome
                            string regExp = @"[^a-zA-Z0-9]";//remove tudo q não seja Letras ou numeros
                            jog1.Nome = Regex.Replace(jog1.Nome, regExp, "");
                            jog1.Letra = Regex.Replace(jog1.Letra, regExp, "");
                            jog1.Letra = jog1.Letra.ToUpper();

                            Jogador jog2 = new Jogador();
                            jog2.Nome = jogadores[1].Split(',')[0];//recupera o nome do segundo jogador
                            jog2.Letra = jogadores[1].Split(',')[1];//recupera a LETRA do segundo jogador
                           
                            
                            //limpa o nome
                            jog2.Nome = Regex.Replace(jog2.Nome, regExp, "");
                            jog2.Letra = Regex.Replace(jog2.Letra, regExp, "");
                            jog2.Letra = jog2.Letra.ToUpper();

                            if ((jog1.Letra != "R" && jog1.Letra != "S" && jog1.Letra != "P") ||
                               (jog2.Letra != "R" && jog2.Letra != "S" && jog2.Letra != "P"))
                            {
                                throw new NoSuchStrategyError("A letras devem ser P ou R ou S ");
                            }

                            subGrupo.ListaJogadores.Add(jog1);
                            subGrupo.ListaJogadores.Add(jog2);

                            grupo.ListaSubGrupo.Add(subGrupo); 
                        }
                    }
                    //adiciona o grupo na lista
                    listGrupoJog.Add(grupo);
                } 
            }
            return listGrupoJog;
        }
    }
}
