export class ExamModel {
  examId?: number;
  tittle?: string;
  description?: string;
  dateRealization?: string;
  dateFinish?: string;

  constructor(ExamId?: number,Tittle?: string, Description?: string, DateRealization?: string, DateFinish?: string) {
    this.examId = ExamId;
    this.tittle = Tittle;
    this.description = Description;
    this.dateRealization = DateRealization;
    this.dateFinish = DateFinish;
  }

  onValid() {
    if(this.description && this.tittle) {
      return this.description.length > 0 && this.tittle.length > 0;
    }
    return false;
  }

  formattedDate(parseDate: string) {
    let date = new Date(parseDate);
    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();

    if(month < 10){
      return `${day}/0${month}/${year}`;
    }else{
      return `${day}/${month}/${year}`;
    }
  }
}
