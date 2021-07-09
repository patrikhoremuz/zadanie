import { Employee, Role } from "@/interfaces";


export interface RootState {
    currentEmployees: Employee[],
    formerEmployees: Employee[],
    roles: Role[],
    selectedEmployee: Employee,
    employeeEditMode: boolean
}