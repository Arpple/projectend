interface IBlockAttack {
    /// <summary>
    /// Active this when this use onBlock eg. Remove charge stack , Remove from Deck , Remove From Box
    /// </summary>
    /// <param name="card">ability card that can block</param>
    /// <returns>number of count/BlockCount that remove on active this</returns>
    int AfterBlockAttack(CardEntity card);
}
