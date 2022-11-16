describe('kendo.cy', () => {
  beforeEach(() => {
    cy.visit('/kendo')
  })

  it('grid works', () => {
    cy.contains('td', 'Star Wars: A New Hope').should('exist')
  })

  it('spreadsheet works', () => {
    cy.contains('.k-spreadsheet-cell', 'Calzone').should('exist')
  })
})
