<script>
  let items = [];
  let newItemText = "";

  loadItems();

  const baseUrl = "http://localhost:5191/items";
  const jsonHeaders = {
    Accept: "application/json",
    "Content-Type": "application/json",
  };

  function loadItems() {
    fetch(baseUrl)
      .then((response) => response.json())
      .then((data) => {
        items = data;
      });
  }

  function deleteItem(id) {
    fetch(`${baseUrl}/${id}`, {
      method: "DELETE",
    }).then(loadItems);
  }

  function addItem() {
    fetch(baseUrl, {
      method: "POST",
      headers: jsonHeaders,
      body: JSON.stringify({ text: newItemText }),
    }).then(() => {
      newItemText = "";
      loadItems();
    });
  }

  function toggleCompleted(item) {
    fetch(`${baseUrl}/${item.id}`, {
      method: "PUT",
      headers: jsonHeaders,
      body: JSON.stringify({ ...item, completed: !item.completed }),
    }).then(loadItems);
  }
</script>

<h1>TODO list</h1>

<ul>
  {#each items as item}
    <li>
      <div
        class="todo-item"
        class:completed={item.completed}
        on:click={() => toggleCompleted(item)}
      >
        {item.completed ? "✓" : "☐"}
        {item.text}
      </div>
      <button on:click={() => deleteItem(item.id)}>X</button>
    </li>
  {/each}

  <li>
    <form on:submit={addItem}>
      <div>
        <input type="text" bind:value={newItemText} />
      </div>
      <button type="submit">Add</button>
    </form>
  </li>
</ul>

<style>
  li {
    text-align: left;
    display: flex;
    flex-direction: row;
    align-items: center;
    gap: 5px;
    padding: 3px;
  }
  li div {
    flex-grow: 1;
    padding: 3px;
  }
  li div.todo-item {
    cursor: pointer;
  }
  li div.todo-item:hover {
    background: #eee;
  }
  li div.todo-item.completed {
    text-decoration: line-through;
  }
  form {
    display: flex;
    flex-direction: row;
    gap: 5px;
    align-items: center;
    width: 100%;
  }
  input {
    padding: 6px;
    font-size: 16px;
  }
</style>
