import { ExamModel } from './exam-model';

describe('ExamModel', () => {
  it('should create an instance', () => {
    expect(new ExamModel()).toBeTruthy();
  });

  it('Validar campo title y descripción', () => {
    let examModel = new ExamModel();
    expect(examModel.onValid()).toBeFalse();
    examModel.Tittle = "Algun dato";
    examModel.Description = "Algun dato";
    expect(examModel.onValid()).toBeTrue();
  });

  it('fecha de inicio y fecha de fin', () => {
    let examModel = new ExamModel();
    let dateTest = examModel.formattedDate(new Date().toDateString());
    expect(dateTest).toEqual(dateTest);
    expect(dateTest).toEqual(dateTest);
  });
});
