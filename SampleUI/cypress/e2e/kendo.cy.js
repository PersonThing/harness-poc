describe('kendo.cy', () => {
  beforeEach(() => {
    cy.visit('/kendo') // have to load this or request to 5191 fails.. since cypress does the request from the current page
  })

  it('grid works', () => {
    cy.contains('td', 'Star Wars: A New Hope').should('exist')
  })

  it('spreadsheet works', () => {
    cy.contains('.k-spreadsheet-cell', 'Calzone').should('exist')
  })
})
