<script>
  import { Router, Route, links } from "svelte-routing";
  import TodoList from "./lib/TodoList.svelte";
  import KendoSample from "./lib/KendoSample.svelte";
</script>

<main>
  <nav use:links>
    <a href="/todo">Todo</a>
    <a href="/kendo">Kendo</a>
  </nav>

  <Router>
    <Route component={TodoList} />
    <Route component={KendoSample} path="/kendo" />
  </Router>
</main>

<style lang="scss">
  main {
    width: 400px;
  }

  nav {
    display: flex;
    flex-direction: row;

    a {
      display: block;
      padding: 10px 15px;
      text-decoration: none;

      &:hover {
        background: #eee;
      }
    }
  }
</style>
