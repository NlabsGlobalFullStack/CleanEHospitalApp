import { RoomTypeEnum } from "./models/enums/room-type-enum.model";
import { VehicleOperationTypeEnum } from "./models/enums/vehicle-operation-type-enum.model";
import { VehicleTypeEnum } from "./models/enums/vehicle.type.model";

export const api: string = "https://localhost:7058";

export const roomTypes: RoomTypeEnum[] = [
    {
        value: 1,
        name: "Patient Room"
    },
    {
        value: 2,
        name: "Operating Room"
    },
    {
        value: 3,
        name: "Intensive Care Room"
    },
    {
        value: 4,
        name: "Emergency Service Room"
    },
    {
        value: 5,
        name: "Other Room"
    }
];

export const vehicleTypes: VehicleTypeEnum[] = [
    {
        value: 1,
        name: "Ambulance"
    },
    {
        value: 2,
        name: "Offical"
    },
    {
        value: 3,
        name: "Service"
    },
];

export const vehicleOperations: VehicleOperationTypeEnum[] = [
    {
        value: 1,
        name: "Satın Alındı"
    },
    {
        value: 2,
        name: "Satıldı"
    },
    {
        value: 3,
        name: "Arızalandı"
    },
    {
        value: 4,
        name: "Arızası Giderildi"
    },
    {
        value: 5,
        name: "Kullanılamaz Halde"
    }
];