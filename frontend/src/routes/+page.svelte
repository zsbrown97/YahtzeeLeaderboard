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


    <div class="flex flex-col items-center justify-center">
        <!-- Player Summary -->
        <PivotTable 
            data={players} 
            tableName={loading ? 'loading' : "player summary"}
            tableVals={playerVals} 
        />
    </div>

<!-- <style lang="postcss">
    @reference "tailwindcss";

    :global(html) {
        background-color: theme(--color-gray-100);
    }
</style> -->