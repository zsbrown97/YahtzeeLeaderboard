<script lang="ts">
  import * as Table from "$lib/components/ui/table/index.js";
  import type { TableValues } from "$lib/types";

  export let data: any[] = [];
  export let tableName: string = "Table Name";
  export let tableVals: TableValues[] = [];

  const pivot = tableVals.map((m) => ({
    label: m.label,
    values: data.map((p) => p[m.key] ?? 0),
  }));
</script>

<h1 class="font-bold mb-4 text-2xl">{tableName}</h1>

<div class="flex flex-col items-center justify-center">
  <div class="w-full max-w-8xl overflow-x-auto">
    <Table.Root>
      <Table.Header>
        <Table.Row>
          <Table.Head></Table.Head>
          {#each data as p}
            <Table.Head>{p.name}</Table.Head>
          {/each}
        </Table.Row>
      </Table.Header>

      <Table.Body>
        {#each pivot as row}
          <Table.Row>
            <Table.Cell><strong>{row.label}</strong></Table.Cell>
            {#each row.values as v}
              <Table.Cell>{v}</Table.Cell>
            {/each}
          </Table.Row>
        {/each}
      </Table.Body>
    </Table.Root>
  </div>
</div>
