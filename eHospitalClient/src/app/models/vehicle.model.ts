import { EntityModel } from "./abstractions/entity.model";
import { VehicleTypeEnum } from "./enums/vehicle.type.model";
import { VehicleActionModel } from "./vehicle-action.model";
import { VehicleMissionModel } from "./vehicle-mission.model";

export class VehicleModel extends EntityModel{
    plate: string = "";
    vehicleType: VehicleTypeEnum = new VehicleTypeEnum();
    vehicleTypeValue: number = 0;
    capacity: number | undefined;

    vehicleActions: VehicleActionModel[] = [];
    vehicleMissions: VehicleMissionModel[] = [];


}