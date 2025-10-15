<script lang="ts">
    import * as Table from "$lib/components/ui/table/index.js";

    export let data;
    const { players } = data;
</script>

<h1 class="font-bold mb-4 text-2xl">
    Players
</h1>

<Table.Root>
    <Table.Header>
        <Table.Row>
            <Table.Head>Name</Table.Head>
            <Table.Head>Grand Total</Table.Head>
        </Table.Row>
    </Table.Header>
    <Table.Body>
        {#each players as p}
            <Table.Row>
                <Table.Cell>{p.name}</Table.Cell>
                <Table.Cell>{p.grandTotal}</Table.Cell>
            </Table.Row>
        {/each}
    </Table.Body>
</Table.Root>

