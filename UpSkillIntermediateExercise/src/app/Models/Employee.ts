export interface Employee
{
    businessEntityId:number | undefined
    nationalIdnumber:string | undefined 
    loginId:string | undefined
    organizationLevel:number | undefined
    jobTitle:string | undefined
    birthDate:Date | undefined
    maritalStatus: string | undefined
    gender:string | undefined
    hireDate:Date | undefined
    salariedFlag:boolean | undefined
    vacationHours:number | undefined
    sickLeaveHours:number | undefined
    currentFlag:boolean | undefined
    rowguid:string | undefined
    modifiedDate:Date | undefined
}