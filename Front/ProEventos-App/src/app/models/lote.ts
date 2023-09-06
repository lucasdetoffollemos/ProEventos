import { Evento } from "./evento";

export interface Lote {
  id: number;
  nome: string;
  preco: number;
  dataInicio?: Date;
  dataFim?: Date;
  eventoId: number;
  evento: Evento;
}
