<script lang="ts">
    import { onMount } from "svelte";

    import PivotTable from "$lib/components/PivotTable.svelte";
    import { getPlayerSummaries } from "$lib/api/players";
    import { playerVals } from "$lib/tableVals";

    let players: any[] = [];
    let loading = true;

    onMount(async () => {
        const [playerData] = await Promise.all([
            getPlayerSummaries(fetch),
        ]);

        players = playerData;
        loading = false;
    });

</script>

{#if loading}
    <p>loading...</p>
{:else}
    <div class="flex flex-col items-center justify-center">
        <!-- Player Summary -->
        <PivotTable 
            data={players} 
            tableName="player summary" 
            tableVals={playerVals} 
        />
    </div>
{/if}
 