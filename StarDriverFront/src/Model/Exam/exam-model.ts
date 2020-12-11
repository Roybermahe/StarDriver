export class ExamModel {
  ExamId?: number;
  Tittle?: string;
  Description?: string;
  DateRealization?: string;
  DateFinish?: string;

  constructor() {
    this.Tittle = "";
    this.Description = "";
    this.DateRealization = "";
    this.DateFinish = "";
  }

  onValid() {
    if(this.Description && this.Tittle) {
      return this.Description.length > 0 && this.Tittle.length > 0;
    }
    return false;
  }
}
