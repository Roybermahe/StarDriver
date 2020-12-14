import { RoomModel } from './room-model';

describe('RoomModel', () => {
  it('should create an instance', () => {
    expect(new RoomModel()).toBeTruthy();
  });

  it('Validar campo nombre', () => {
    let roomModel = new RoomModel();
    expect(roomModel.onValid()).toBeFalse();
    roomModel.Name = "Algun dato";
    roomModel.Description = "Algun dato";
    expect(roomModel.onValid()).toBeTrue();
  });
});
