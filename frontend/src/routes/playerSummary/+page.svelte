<script lang="ts">
    import PivotTable from "$lib/components/PivotTable.svelte";

    export let data;
    const { players, mostRecentGames } = data;

    const playerMap = new Map(players.map((p: any) => [p.id, p.name]))

    const playerVals = [
        { label: "Grand Total", key: 'grandTotal' },
        { label: "Games Played", key: 'gamesPlayed' },
        { label: "Wins", key: 'wins' }
    ]

    const recentGameVals = [
        { label: "Ones", key: 'ones' },
        { label: "Twos", key: 'twos' },
        { label: "Threes", key: 'threes' },
        { label: "Fours", key: 'fours' },
        { label: "Fives", key: 'fives' },
        { label: "Sixes", key: 'sixes' }
    ]

    const recentGamesWithPlayerNames = mostRecentGames.map((g: any) => ({
        ...g,
        name: playerMap.get(g.playerId) ?? g.name ?? 'n/a'
    }))


</script>

<h1 class="font-bold mb-4 text-2xl">
    Players
</h1>

<div class="flex flex-col items-center justify-center">
    <!-- Player Summary -->
    <PivotTable 
        data={players} 
        tableName="player summary" 
        tableVals={playerVals} 
    />

    <!-- Latest scores -->
     <PivotTable
        data={recentGamesWithPlayerNames}
        tableName="recent game"
        tableVals={recentGameVals}
    />
</div>


 