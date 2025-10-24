<script lang="ts">
    import { onMount } from "svelte";

    import PivotTable from "$lib/components/PivotTable.svelte";
    import { getPlayerSummaries, getMostRecentGames } from "$lib/api/players";
    import { scorecardVals } from "$lib/tableVals";

    let players: any[] = [];
    let mostRecentGames: any[] = [];
    let loading = true;

    onMount(async () => {
        const [playerData, gameData] = await Promise.all([
            getPlayerSummaries(fetch), 
            getMostRecentGames(fetch)
        ]);
        players = playerData;
        mostRecentGames = gameData;
        loading = false;
    });

    $: playerMap = new Map(players.map((p: any) => [p.id, p.name]))
    $: recentGamesWithPlayerNames = mostRecentGames.map((g: any) => ({
        ...g,
        name: playerMap.get(g.playerId) ?? g.name ?? 'n/a'
    }))

</script>

{#if loading}
    <p>loading...</p>
{:else}
    <div class="flex flex-col items-center justify-center">
        <!-- Latest scores -->
        <PivotTable
            data={recentGamesWithPlayerNames}
            tableName="recent game"
            tableVals={scorecardVals}
        />
    </div>
{/if}
 