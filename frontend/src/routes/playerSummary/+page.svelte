<script lang="ts">
    import PivotTable from "$lib/components/PivotTable.svelte";

    export let data;
    const { players } = data;

    const playerVals = [
        { label: "Grand Total", key: 'grandTotal' },
        { label: "Games Played", key: 'gamesPlayed' },
        { label: "Wins", key: 'wins' }
    ]

    const pivot = playerVals.map(m => ({
        label: m.label,
        values: players.map((p: any) => p[m.key] ?? 0)
    }))

</script>

<h1 class="font-bold mb-4 text-2xl">
    Players
</h1>

<div class="flex flex-col items-center justify-center">
    <PivotTable 
        data={players} 
        tableName="player summary" 
        tableVals={playerVals} 
    />
</div>


 