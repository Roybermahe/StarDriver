import {PersonModel, Specialization} from './person-model';

describe('PersonModel', () => {
  it('should create an instance', () => {
    expect(new PersonModel(0,"","","","","", "Apprentice")).toBeTruthy();
  });

  it('Validar campo identificacion y nombre', () => {
    let personModel = new PersonModel(0,"","","","","", "Apprentice");
    expect(personModel.onValid()).toBeFalse();
    expect(personModel.onValid()).toBeTrue();
  });

  it('split', () => {
    let personModel = new PersonModel(0,"","","","","", "Apprentice");
    let lista: Specialization[] = [{
      name: "X"},
      {
        name: "Y"},
      {
        name: "Z"}
    ];
    personModel.onSpecialization(lista);
    expect(personModel.Specialization).toEqual("X|Y|Z");
  });
});
