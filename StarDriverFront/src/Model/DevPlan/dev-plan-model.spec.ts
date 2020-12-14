import { DevPlanModel } from './dev-plan-model';
import {RoomModel} from "../Room/room-model";

describe('DevPlanModel', () => {
  it('should create an instance', () => {
    expect(new DevPlanModel()).toBeTruthy();
  });

  it('Validar campo nivel', () => {
    let devPlanModel = new DevPlanModel();
    expect(devPlanModel.onValid()).toBeFalse();
    devPlanModel.level = "Algun dato";
    expect(devPlanModel.onValid()).toBeTrue();
  });

});
