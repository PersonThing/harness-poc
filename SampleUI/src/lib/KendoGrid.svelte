<script>
  // data you want in the grid
  export let data;

  let container = null;

  $: if (container != null && data != null) {
    // when container and data are set / change, create a new kendoGrid
    // we could optimize this to only instantiate once and use methods inside kendoGrid to update its data
    jQuery(container).kendoGrid({
      dataSource: new kendo.data.DataSource({
        data,
      }),
    });
  }
</script>

<div bind:this={container}></div>
