export interface Card {
  pin: number;
  cvv: number;
  monthExp: number;
  yearExp: number;
  sold: number;
}

export interface AddFromCard {
  username: string;
  idCard: number;
  amount: number;
}
