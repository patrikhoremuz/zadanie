import moment from "moment";

export interface Employee{
    id: number,
    firstName: string,
    lastName: string,
    address: string,
    dateOfBirth: moment.Moment | string,
    validFrom: moment.Moment  | string,
    role: number,
    roleName: string,
    salary: number,
    roles: EmployeeRole[]
}

export interface Role{
    id: number,
    roleName: string
}

export interface EmployeeRole{
    id: number,
    roleId: number,
    personId: number,
    validTo: moment.Moment | string,
    validFrom: moment.Moment  | string,
    roleName: string
}