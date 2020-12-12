import { PersonModel } from './person-model';

describe('PersonModel', () => {
  it('should create an instance', () => {
    expect(new PersonModel()).toBeTruthy();
  });

  it('Validar campo identificacion y nombre', () => {
    let personModel = new PersonModel();
    expect(personModel.onValid()).toBeFalse();
    personModel.Identificacion = 1003376884;
    personModel.Name = "Algun dato";
    expect(personModel.onValid()).toBeTrue();
  });
});
