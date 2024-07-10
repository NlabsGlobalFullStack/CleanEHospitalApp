import { RoomTypeModel } from "./models/room.model";
import { VehicleOperationModel } from "./models/vehicle-action.model";
import { VehicleTypeModel } from "./models/vehicle.model";

export const api: string = "https://localhost:7058";

export const roomTypes: RoomTypeModel[] = [
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

export const vehicleTypes: VehicleTypeModel[] = [
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

export const vehicleOperations: VehicleOperationModel[] = [
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