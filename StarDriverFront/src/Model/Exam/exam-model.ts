export class ExamModel {
  ExamId?: number;
  Tittle?: string;
  Description?: string;
  DateRealization?: string;
  DateFinish?: string;

  constructor(ExamId?: number,Tittle?: string, Description?: string, DateRealization?: string, DateFinish?: string) {
    this.ExamId = ExamId;
    this.Tittle = Tittle;
    this.Description = Description;
    this.DateRealization = DateRealization;
    this.DateFinish = DateFinish;
  }

  onValid() {
    if(this.Description && this.Tittle) {
      return this.Description.length > 0 && this.Tittle.length > 0;
    }
    return false;
  }

  formattedDate(parseDate: string) {
    let date = new Date(parseDate)
    let day = date.getDate()
    let month = date.getMonth() + 1
    let year = date.getFullYear()

    if(month < 10){
      return `${day}/0${month}/${year}`;
    }else{
      return `${day}/${month}/${year}`;
    }
  }
}
