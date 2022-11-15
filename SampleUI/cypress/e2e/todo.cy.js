describe('todo.cy', () => {
  beforeEach(() => {
    cy.visit('/') // have to load this or request to 5191 fails.. since cypress does the request from the current page
    cy.request('http://localhost:5191/items/seed')
    cy.reload()
  })

  it('can add', () => {
    const newTodoText = "this is a sample todo"
    assertTodoLength(2)

    addTodo(newTodoText)
    assertTodoLength(3)
    assertTodoExists(newTodoText)
  })

  it('can delete', () => {
    const nameToDelete = 'Sample 1' 
    assertTodoLength(2)
    deleteTodo(nameToDelete)
    assertTodoLength(1)
    assertTodoExists(nameToDelete, false)
  })

  it('can toggle completed', () => {
    const nameToToggle = 'Sample 1'
    assertCompleted(nameToToggle, false)
    toggleCompleted(nameToToggle)
    assertCompleted(nameToToggle, true)
    toggleCompleted(nameToToggle)
    assertCompleted(nameToToggle, false)
    assertTodoLength(2)
  })
})

function assertTodoLength(len) {
  cy.get('.todo-item').should('have.length', len)
}

function assertTodoExists(text, shouldExist = true) {
  cy.contains('.todo-item', text).should(shouldExist ? 'exist' : 'not.exist')
}

function addTodo(text) {
  cy.get('input[type=text]').type(text + '{enter}')
}

function deleteTodo(text) {
  cy.contains('li', text).find('button').click()
}

function toggleCompleted(text) {
  cy.contains('.todo-item', text).click()
}

function assertCompleted(text, shouldBeCompleted = true) {
  cy.contains('.todo-item', text).should(shouldBeCompleted ? 'have.class' : 'not.have.class', 'completed')
}