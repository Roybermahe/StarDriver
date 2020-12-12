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
});
