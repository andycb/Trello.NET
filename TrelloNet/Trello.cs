﻿using System;
using System.Collections.Generic;
using TrelloNet.Internal;
using TrelloNet.Internal.Requests;

namespace TrelloNet
{
	public class Trello : ITrello
	{
		private readonly TrelloRestClient _restClient;
		private readonly IMembers _members;

		public Trello(string key)
		{
			_restClient = new TrelloRestClient(key);
			_members = new Members(_restClient);
		}

		public IMembers Members
		{
			get { return _members; }
		}

		public void Authenticate(string token)
		{
			_restClient.Authenticate(token);
		}

		public Uri GetAuthenticationUrl(string applicationName)
		{
			return _restClient.GetAuthenticationlUrl(applicationName, AccessMode.ReadOnly);
		}

		public IEnumerable<Board> Boards(IMemberId member, BoardFilter filter = BoardFilter.All)
		{
			return _restClient.Request<List<Board>>(new MemberBoardsRequest(member, filter));
		}

		public IEnumerable<Board> Boards(IOrganizationId organization, BoardFilter filter = BoardFilter.All)
		{
			return _restClient.Request<List<Board>>(new OrganizationBoardsRequest(organization, filter));
		}

		public Board Board(string boardId)
		{
			return _restClient.Request<Board>(new BoardRequest(boardId));
		}

		public Board Board(ICardId card)
		{
			return _restClient.Request<Board>(new CardBoardRequest(card));
		}

		public Board Board(IChecklistId checklist)
		{
			return _restClient.Request<Board>(new ChecklistBoardRequest(checklist));
		}

		public Board Board(IListId list)
		{
			return _restClient.Request<Board>(new ListBoardRequest(list));
		}

		public List List(string listId)
		{
			return _restClient.Request<List>(new ListRequest(listId));
		}

		public List List(ICardId card)
		{
			return _restClient.Request<List>(new CardListRequest(card));
		}

		public IEnumerable<List> Lists(IBoardId board, ListFilter filter = ListFilter.None)
		{
			return _restClient.Request<List<List>>(new BoardListsRequest(board, filter));
		}

		public IEnumerable<Card> Cards(IBoardId board, CardFilter filter = CardFilter.Open)
		{
			return _restClient.Request<List<Card>>(new BoardCardsRequest(board, filter));
		}

		public IEnumerable<Card> Cards(IListId list, CardFilter filter = CardFilter.Open)
		{
			return _restClient.Request<List<Card>>(new ListCardsRequest(list, filter));
		}

		public IEnumerable<Card> Cards(IMemberId member, CardFilter filter = CardFilter.Open)
		{
			return _restClient.Request<List<Card>>(new MemberCardsRequest(member, filter));
		}

		public IEnumerable<Card> Cards(IChecklistId checklist, CardFilter filter = CardFilter.Open)
		{
			return _restClient.Request<List<Card>>(new ChecklistCardsRequest(checklist, filter));
		}

		public Card Card(string cardId)
		{
			return _restClient.Request<Card>(new CardRequest(cardId));
		}

		public IEnumerable<Checklist> Checklists(IBoardId board)
		{
			return _restClient.Request<List<Checklist>>(new BoardChecklistsRequest(board));
		}

		public IEnumerable<Checklist> Checklists(ICardId card)
		{
			return _restClient.Request<List<Checklist>>(new CardChecklistsRequest(card));
		}

		public Checklist Checklist(string checkListId)
		{
			return _restClient.Request<Checklist>(new ChecklistRequest(checkListId));
		}

		public Organization Organization(string orgIdOrName)
		{
			return _restClient.Request<Organization>(new OrganizationRequest(orgIdOrName));
		}

		public Organization Organization(IBoardId board)
		{
			return _restClient.Request<Organization>(new BoardOrganizationRequest(board));
		}

		public IEnumerable<Organization> Organizations(IMemberId member, OrganizationFilter filter = OrganizationFilter.All)
		{
			return _restClient.Request<List<Organization>>(new MemberOrganizationsRequest(member, filter));
		}
	}
}