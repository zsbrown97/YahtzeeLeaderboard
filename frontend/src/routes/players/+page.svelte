<script lang="ts">
    import * as Table from "$lib/components/ui/table/index.js";

    export let data;
    const { players, mostRecentGames} = data;
</script>

<h1 class="font-bold mb-4 text-2xl">
    Players
</h1>

<div class="flex flex-col items-center justify-center">
    <div class="w=full max-w-8xl overflow-x-auto">
        <Table.Root>
            <Table.Header>
                <Table.Row>
                    <Table.Head>Name</Table.Head>
                    <Table.Head>Grand Total</Table.Head>
                    <Table.Head>No. of Games</Table.Head>
                    <Table.Head>Wins</Table.Head>
                </Table.Row>
            </Table.Header>
            <Table.Body>
                {#each players as p}
                        <Table.Row>
                            <Table.Cell>{p.name}</Table.Cell>
                            <Table.Cell>{p.grandTotal}</Table.Cell>
                            <Table.Cell>{p.gamesPlayed}</Table.Cell>
                            <Table.Cell>{p.wins}</Table.Cell>
                        </Table.Row>
                {/each}
            </Table.Body>
        </Table.Root>
    </div>
</div>
<!-- <Table.Root>
    <Table.Header>
        <Table.Row>
            <Table.Head>Name</Table.Head>
            <Table.Head>Ones</Table.Head>
            <Table.Head>Twos</Table.Head>
            <Table.Head>Threes</Table.Head>
            <Table.Head>Fours</Table.Head>
            <Table.Head>Fives</Table.Head>
            <Table.Head>Sixes</Table.Head>
            <Table.Head>Upper Bonus</Table.Head>
            <Table.Head>Upper Total</Table.Head>
            <Table.Head>Three of a Kind</Table.Head>
            <Table.Head>Four of a Kind</Table.Head>
            <Table.Head>Full House</Table.Head>
            <Table.Head>Small Straight</Table.Head>
            <Table.Head>Large Straight</Table.Head>
            <Table.Head>Yahtzee</Table.Head>
            <Table.Head>Bonus Yahtzees</Table.Head>
            <Table.Head>Chance</Table.Head>
            <Table.Head>Upper Total</Table.Head>
        </Table.Row>
    </Table.Header>

    <Table.Body>
        {#each mostRecentGames as game}
            <Table.Row>
                <Table.Cell>{game.playerName}</Table.Cell>
                <Table.Cell>{game.ones}</Table.Cell>
                <Table.Cell>{game.twos}</Table.Cell>
                <Table.Cell>{game.threes}</Table.Cell>
                <Table.Cell>{game.fours}</Table.Cell>
                <Table.Cell>{game.fives}</Table.Cell>
                <Table.Cell>{game.sixes}</Table.Cell>
                <Table.Cell>{game.upperBonus}</Table.Cell>
                <Table.Cell>{game.upperTotal}</Table.Cell>
                <Table.Cell>{game.threeOfAKind}</Table.Cell>
                <Table.Cell>{game.fourOfAKind}</Table.Cell>
                <Table.Cell>{game.fullHouse}</Table.Cell>
                <Table.Cell>{game.smStraight}</Table.Cell>
                <Table.Cell>{game.lgStraight}</Table.Cell>
                <Table.Cell>{game.yahtzee}</Table.Cell>
                <Table.Cell>{game.bonusYahtzees}</Table.Cell>
                <Table.Cell>{game.chance}</Table.Cell>
                <Table.Cell>{game.grandTotal}</Table.Cell>
            
            </Table.Row> 
        {/each}
    </Table.Body>
</Table.Root>
    -->

