<script>
  import KendoGrid from "./KendoGrid.svelte";
  import KendoSpreadsheet from "./KendoSpreadsheet.svelte";

  const sampleGridData = [
    { Title: "Star Wars: A New Hope", Year: 1977 },
    { Title: "Star Wars: The Empire Strikes Back", Year: 1980 },
    { Title: "Star Wars: Return of the Jedi", Year: 1983 },
  ];
</script>

<h2>KendoGrid</h2>
<KendoGrid data={sampleGridData} />

<h2>KendoSpreadsheet</h2>
<KendoSpreadsheet />
