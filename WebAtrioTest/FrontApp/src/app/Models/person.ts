export class Person {
    id : number;
    nom: string;
    prenom: string;
    dateDeNaissance : Date;
    emploi:string;
    age:number;


    constructor(Id: number, nom: string,prenom: string, dateDeNaissance: Date, emploi:string, age:number) {
        this.id = Id;
        this.nom = nom;
        this.prenom = prenom;
        this.dateDeNaissance = dateDeNaissance;
        this.emploi=emploi;
        this.age=age;
      }
}


