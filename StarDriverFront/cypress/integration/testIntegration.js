const { createYield } = require("typescript")

describe('TestPaginaView', function(){

  it('navegationTest', function(){
    cy.visit('http://localhost:4200/Index');
    cy.get('[ng-reflect-router-link="/index"] > .mat-button-wrapper').click();
    cy.get('#Btn-CrearPersona').click();
    cy.get('[mat-dialog-close=""] > .mat-button-wrapper').click();
    cy.get('#Btn-ActualizarPersona > .mat-button-wrapper > .mat-icon').click();
    cy.get('[mat-dialog-close=""] > .mat-button-wrapper').click();

    cy.get('[ng-reflect-router-link="/room"] > .mat-button-wrapper').click();
    cy.get('#btn-crearsalon > .mat-button-wrapper').click();
    cy.get('[mat-dialog-close=""] > .mat-button-wrapper').click();

  });

  it('testSavePerson', function(){

  });

});
